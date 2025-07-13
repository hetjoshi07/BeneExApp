using AutoMapper;
using BeneExApp.Domain;
using BeneExApp.DTOs;
using BeneExApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeneExApp.Controllers
{
    /// <summary>
    /// This controller handles request and response operations related to beneficiaries.
    /// </summary>
    public class BeneficiaryController : Controller
    {
        #region Fields

        private readonly IBeneficiaryRepository _beneficiaryRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public BeneficiaryController(IBeneficiaryRepository beneficiaryRepository, IMapper mapper)
        {
            _beneficiaryRepository = beneficiaryRepository;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves a list of beneficiaries.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the list of beneficiaries.</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var beneficiaries = await _beneficiaryRepository.GetAllAsync();
            return View(_mapper.Map<List<BeneficiaryRequestDto>>(beneficiaries));
        }

        /// <summary>
        /// Displays the view for adding a new beneficiary.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> that renders the view for adding a new beneficiary.</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds a new beneficiary.
        /// </summary>
        /// <param name="request">The data transfer object containing the details of the beneficiary to add.</param>
        /// <returns>A task that represents the asynchronous operation. The result is redirects to the "List" 
        /// view upon success, or re-displays the "Add" view with validation errors if the model state is invalid.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BeneficiaryRequestDto request)
        {
            if (!ModelState.IsValid)
                return View("Add", ModelState);

            var beneficiary = await _beneficiaryRepository.AddAsync(_mapper.Map<Beneficiary>(request));
            await _beneficiaryRepository.Save();
            return RedirectToAction("List");
        }

        /// <summary>
        /// Edits an existing beneficiary identified by the provided ID.
        /// </summary>
        /// <param name="id">The unique identifier of the beneficiary to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> that renders the view for existing beneficiary.</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var beneficiary = await _beneficiaryRepository.GetAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<BeneficiaryRequestDto>(beneficiary));
        }

        /// <summary>
        /// Updates the details of an existing beneficiary.
        /// </summary>
        /// <param name="request">The data transfar object contains update details of the beneficiary.</param>
        /// <returns>A task that represents the asynchronous operation. The result is redirects to the "List" 
        /// view upon success, or re-displays the "Edit" view with validation errors if the model state is invalid.</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BeneficiaryRequestDto request)
        {
            if (!ModelState.IsValid)
                return View("Edit", ModelState);

            var beneficiary = _mapper.Map<Beneficiary>(request);
            await _beneficiaryRepository.UpdateAsync(beneficiary);
            await _beneficiaryRepository.Save();
            return RedirectToAction("List");
        }

        /// <summary>
        /// Displays the details of a specific Beneficiary by ID.
        /// </summary>
        /// <param name="id">The ID of the Beneficiary to view.</param>
        /// <returns>The Details view if the Beneficiary is found; otherwise, NotFound result.</returns>
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var beneficiary = await _beneficiaryRepository.GetAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<BeneficiaryRequestDto>(beneficiary));
        }

        #endregion
    }
}