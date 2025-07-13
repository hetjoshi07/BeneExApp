using AutoMapper;
using BeneExApp.Domain;
using BeneExApp.DTOs;
using BeneExApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeneExApp.Controllers
{
    /// <summary>
    /// This controller handles request and response operations related to expenditures.
    /// </summary>
    public class ExpenditureController : Controller
    {
        #region Fields

        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ExpenditureController(
            IBeneficiaryRepository beneficiaryRepository,
            IExpenditureRepository expenditureRepository,
            IMapper mapper)
        {
            _beneficiaryRepository = beneficiaryRepository;
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves a list of expenditures.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the list of expenditure.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var expenditures = await _expenditureRepository.GetAllAsync();
            return View(_mapper.Map<List<ExpenditureRequestDto>>(expenditures));
        }

        /// <summary>
        /// Displays the view for adding a new expenditure.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> that renders the view for adding a new expenditure.</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Beneficiaries = new SelectList(await _beneficiaryRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        /// <summary>
        /// Adds a new expenditure.
        /// </summary>
        /// <param name="request">The data transfer object containing the details of the expenditure to add.</param>
        /// <returns>A task that represents the asynchronous operation. The result is redirects to the "List" 
        /// view upon success, or re-displays the "Add" view with validation errors if the model state is invalid. </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ExpenditureRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Beneficiaries = new SelectList(await _beneficiaryRepository.GetAllAsync(), "Id", "Name");
                return View(request);
            }

            var expenditure = await _expenditureRepository.AddAsync(_mapper.Map<Expenditure>(request));
            await _expenditureRepository.SaveAsync();
            return RedirectToAction("List", "Expenditure");
        }

        /// <summary>
        /// Edits an existing expenditure identified by the provided ID.
        /// </summary>
        /// <param name="id">The unique identifier of the expenditure to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> that renders the view for existing expenditure.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var expenditure = await _expenditureRepository.GetAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            var request = _mapper.Map<ExpenditureRequestDto>(expenditure);
            ViewBag.Beneficiaries = new SelectList(await _beneficiaryRepository.GetAllAsync(), "Id", "Name", request.BeneficiaryId);
            return View(request);
        }

        /// <summary>
        /// Updates the details of an existing expenditure.
        /// </summary>
        /// <param name="request">The data transfar object contains update details of the expenditure.</param>
        /// <returns>A task that represents the asynchronous operation. The result is redirects to the "List" 
        /// view upon success, or re-displays the "Edit" view with validation errors if the model state is invalid.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExpenditureRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Beneficiaries = new SelectList(await _beneficiaryRepository.GetAllAsync(), "Id", "Name", request.BeneficiaryId);
                return View(request);
            }
            var expenditure = await _expenditureRepository.UpdateAsync(_mapper.Map<Expenditure>(request));
            await _expenditureRepository.SaveAsync();
            return RedirectToAction("List", "Expenditure");
        }

        /// <summary>
        /// Displays the details of a specific expenditure by ID.
        /// </summary>
        /// <param name="id">The ID of the expenditure to view.</param>
        /// <returns>The Details view if the expenditure is found; otherwise, NotFound result.</returns>
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var expenditure = await _expenditureRepository.GetAsync(id);
            if (expenditure == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ExpenditureRequestDto>(expenditure));
        }

        #endregion
    }
}